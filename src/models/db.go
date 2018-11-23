package models

import (
	"database/sql"

	_ "github.com/lib/pq"
)

type DB struct {
	*sql.DB
}

func (db *DB) GetAllBatteries() ([]*BatteryResponse, error) {
	var err error

	query := "SELECT id, name FROM battery"
	rows, err := db.DB.Query(query)
	if err != nil {
		return nil, err
	}
	defer rows.Close()
	batteries := make([]*BatteryResponse, 0)
	for rows.Next() {
		battery := new(BatteryResponse)
		err = rows.Scan(
			&battery.Id,
			&battery.Name,
		)
		batteries = append(batteries, battery)
	}
	if err = rows.Err(); err != nil {
		return nil, err
	}
	return batteries, nil
}

func (db *DB) AddBattery(in BatteryRequest) error {
	var err error
	query := "INSERT INTO battery (name) VALUES ($1)"
	_, err = db.DB.Query(query, in.Name)
	return err
}

func GetDb() (*DB, error) {
	dbUser := "postgres"
	dbPassword := "postgres"
	dbName := "forge"
	connectionString := "postgres://" + dbUser + ":" + dbPassword + "@localhost/" + dbName + "?sslmode=disable"

	db, err := sql.Open("postgres", connectionString)
	if err != nil {
		return nil, err
	}
	return &DB{db}, nil
}

// TODO: do i need to close the database?
func CloseDb(db *sql.DB) {
	db.Close()
}
