FROM python:2.7-alpine

WORKDIR /app

COPY requirements.txt /app/requirements.txt
RUN pip install -r requirements.txt

COPY . /app

EXPOSE 80

CMD ["gunicorn", "app:app", "-b", "0.0.0.0:80"]
