#!/bin/bash

VOLUME_NAME="dbdata"

docker-compose down
if docker volume ls -q --filter name="$VOLUME_NAME" | grep -q "$VOLUME_NAME"; then
  echo "The volume $VOLUME_NAME exist!"
  echo "Remove volume..."
  docker volume rm "$VOLUME_NAME"
fi
echo "Create volume $VOLUME_NAME"
docker volume create "$VOLUME_NAME"
echo "Start docker-compose..."
docker-compose up --build
