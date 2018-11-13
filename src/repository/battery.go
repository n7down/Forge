package repository

import (
	"database/sql"

	_ "github.com/go-sql-driver/mysql"
)

func CreateBattery(name string) {
	db, err := sql.Open("mysql", "root:root@/forge")
	if err != nil {
		panic(err.Error)
	}
	defer db.Close()
}
