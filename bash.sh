#!/bin/bash

docker pull postgres

docker network create book_store_network
docker run --name postgres_container --network book_store_network -e POSTGRES_USER=postgres -e POSTGRES_PASSWORD=Qjf39JK2Njuw194 -e POSTGRES_DB=bookstore -p 5432:5432 -d postgres

docker build -t web .
docker run -p 8081:8081 --name webApp --network book_store_network -d web:latest