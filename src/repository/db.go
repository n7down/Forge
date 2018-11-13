package repository

import (
	"database/sql"
	"errors"

	_ "github.com/go-sql-driver/mysql"
)

var db *sql.DB

func InitDb() {
	if db != nil {
		return
	}

	dbUser := "root"
	dbPassword := "root"
	dbConnection := "forge"

	db, _ := sql.Open("mysql", dbUser+":"+dbPassword+" @/"+dbConnection)
}

func GetDB() (*sql.DB, error) {
	if db == nil {
		return db, errors.New("no db")
	}
	return db, nil
}
