FROM python:3.7.2-slim

WORKDIR /myApp
COPY /requirements/backend-versions.txt /myApp/requirements/backend-versions.txt
RUN pip install -r requirements/backend-versions.txt

COPY build/index.html /myApp/build/index.html
COPY /spaceship /myApp/spaceship

CMD [ "uvicorn", "spaceship.main:app", "--host=0.0.0.0", "--port=8080", "--reload"]