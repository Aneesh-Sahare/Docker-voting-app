# Docker-voting-app
<img width="1920" height="1080" alt="image" src="https://github.com/user-attachments/assets/8a4cd8c3-2ce9-4de6-b313-22b6866ff576" />


The voting application is composed of several distinct components:

Voting App: A Python-based web application built with Flask, where users cast their votes.
Redis: A messaging system that collects the submitted votes.
Worker: A .NET application (with a Java-like code sample preserved) that processes votes and updates a PostgreSQL database.
Result App: A Node.js and Express application that retrieves and displays voting results from the database.
