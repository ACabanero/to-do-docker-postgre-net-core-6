@echo off

set VOLUME_NAME=dbdata

docker-compose down
docker volume inspect %VOLUME_NAME% >nul 2>&1
if %errorlevel% equ 0 (
  echo The volume %VOLUME_NAME% exist!
  echo Remove volume...
  docker volume rm %VOLUME_NAME%
)
echo Create volume %VOLUME_NAME%.
docker volume create %VOLUME_NAME%
echo "Start docker-compose..."
docker-compose up --build
