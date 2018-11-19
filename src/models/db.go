package models

import (
	"database/sql"

	_ "github.com/go-sql-driver/mysql"
)

func GetDb() (*sql.DB, error) {
	dbUser := "root"
	dbPassword := "root"
	dbConnection := "forge"

	db, err := sql.Open("mysql", dbUser+":"+dbPassword+"@/"+dbConnection)
	if err != nil {
		return nil, err
	}
	return db, nil
}

// TODO: do i need to close the database?
func CloseDb(db *sql.DB) {
	db.Close()
}
