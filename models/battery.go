package models

import (
	"database/sql"
)

type BatteryRequest struct {
	Name string `json:"name"`
}

type BatteryResponse struct {
	Id   int    `json:"id"`
	Name string `json:"name"`
}

type Battery struct {
}

func (b Battery) GetAllBatteries(db *sql.DB) ([]*BatteryResponse, error) {
	var err error

	query := "SELECT id, name FROM battery"
	rows, err := db.Query(query)
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

func (b Battery) AddBattery(db *sql.DB, in BatteryRequest) error {
	var err error
	query := "INSERT INTO battery (name) VALUES ($1)"
	_, err = db.Query(query, in.Name)
	return err
}
