FROM postgres:alpine3.18

LABEL author="DemoMan"
LABEL description="Postgres demo database"
LABEL version="1.0"

WORKDIR /database
COPY database/scripts/*.sql /docker-entrypoint-initdb.d/

# Cambia el propietario y los permisos del archivo SQL
RUN chown postgres:postgres /docker-entrypoint-initdb.d/*.sql
RUN chmod 755 /docker-entrypoint-initdb.d/*.sql