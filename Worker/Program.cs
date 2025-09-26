package worker;


import redis.clients.jedis.Jedis;
import redis.clients.jedis.exceptions.JedisConnectionException;
import java.sql.*;
import org.json.JSONObject;


class Worker {
    public static void main(String[] args) {
        try {
            Jedis redis = connectToRedis("redis");
            Connection dbConn = connectToDB("db");


            System.err.println("Watching vote queue");


            while (true) {
                String voteJSON = redis.blpop("votes").get(1);
                JSONObject voteData = new JSONObject(voteJSON);
                String voterID = voteData.getString("voter_id");
                String vote = voteData.getString("vote");


                System.err.printf("Processing vote for '%s' by '%s'\n", vote, voterID);
                updateVote(dbConn, voterID, vote);
            }
        } catch (SQLException e) {
            e.printStackTrace();
            System.exit(1);
        }
    }


    static void updateVote(Connection dbConn, String voterID, String vote) throws SQLException {
        PreparedStatement insert = dbConn.prepareStatement(
            "INSERT INTO votes (id, vote) VALUES (?, ?)"
        );
        insert.setString(1, voterID);
        insert.setString(2, vote);
        // Execute the update (execution omitted in the sample)
    }
}
