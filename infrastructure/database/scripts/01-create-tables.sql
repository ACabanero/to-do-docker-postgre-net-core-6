-- INSTALL unaccent
CREATE EXTENSION unaccent;

-- CREATE TABLE
CREATE TABLE IF NOT EXISTS todo (
    id SERIAL PRIMARY KEY,
    title VARCHAR NOT NULL,
    filter VARCHAR NOT NULL,
    isCompleted BOOLEAN NOT NULL,
    dateCreated DATE NOT NULL,
    dateUpdated DATE NOT NULL
);