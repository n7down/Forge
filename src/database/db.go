package database

import (
	"database/sql"
	"errors"

	_ "github.com/go-sql-driver/mysql"
)

var db *sql.DB

func InitDb() error {
	var err error
	if db != nil {
		return errors.New("db already created")
	}

	dbUser := "root"
	dbPassword := "root"
	dbConnection := "forge"

	db, err = sql.Open("mysql", dbUser+":"+dbPassword+"@tcp(127.0.0.1:3306)/"+dbConnection)
	return err
}

func GetDb() (*sql.DB, error) {
	if db == nil {
		return db, errors.New("no db")
	}
	return db, nil
}
