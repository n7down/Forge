package models

import (
	"database/sql"
	"os"

	_ "github.com/lib/pq"
)

type DB struct {
	Db *sql.DB
}

func getEnv(key, fallback string) string {
	if value, ok := os.LookupEnv(key); ok {
		return value
	}
	return fallback
}

//func GetDB() (*DB, error) {
//dbUser := "postgres"
//dbPassword := "postgres"
//dbName := "forge"
//dbHost := getEnv("DB_HOST", "localhost")
//connectionString := "postgres://" + dbUser + ":" + dbPassword + "@" + dbHost + "/" + dbName + "?sslmode=disable"

//db, err := sql.Open("postgres", connectionString)
//if err != nil {
//return nil, err
//}
//return &DB{Db: db}, nil
//}

func GetDB() (*sql.DB, error) {
	dbUser := "postgres"
	dbPassword := "postgres"
	dbName := "forge"
	dbHost := getEnv("DB_HOST", "localhost")
	connectionString := "postgres://" + dbUser + ":" + dbPassword + "@" + dbHost + "/" + dbName + "?sslmode=disable"

	db, err := sql.Open("postgres", connectionString)
	if err != nil {
		return nil, err
	}
	return db, nil
}

// TODO: do i need to close the database?
func CloseDb(db *sql.DB) {
	db.Close()
}
