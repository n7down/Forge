package repository

import (
	data "github.com/n7down/Forge/src/database"
	models "github.com/n7down/Forge/src/models"
)

func CreateBattery(in models.BatteryRequest) error {
	query := "INSERT INTO battery (name) VALUES (?)"
	db, err := data.GetDb()
	if err != nil {
		return err
	}
	_, err = db.Exec(query, in.Name)
	return err
}

func GetBatteries() ([]models.BatteryResponse, error) {
	var (
		battery   models.BatteryResponse
		batteries []models.BatteryResponse
		err       error
	)

	query := "SELECT id, name FROM battery"
	db, err := data.GetDb()
	if err != nil {
		return batteries, err
	}
	rows, err := db.Query(query)
	defer rows.Close()
	for rows.Next() {
		err = rows.Scan(
			&battery.Id,
			&battery.Name,
		)
		batteries = append(batteries, battery)
	}
	return batteries, err
}
