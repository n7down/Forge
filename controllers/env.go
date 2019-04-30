package controllers

import (
	"database/sql"
)

type Env struct {
	Db *sql.DB
}
