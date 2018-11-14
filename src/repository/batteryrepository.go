package repository

import (
	data "github.com/n7down/Forge/src/database"
	request "github.com/n7down/Forge/src/models"
	response "github.com/n7down/Forge/src/models"
)

func CreateBattery(in request.Battery) error {
	query := "INSERT INTO battery (name) VALUES (?)"
	db, err := data.GetDb()
	if err != nil {
		return err
	}
	_, err = db.Exec(query, in.Name)
	return err
}

func GetBatteries() ([]response.Battery, error) {
	var (
		battery   response.Battery
		batteries []response.Battery
		err       error
	)

	query := "SELECT name FROM battery"
	db, err := data.GetDb()
	if err != nil {
		return batteries, err
	}
	rows, err := db.Query(query)
	defer rows.Close()
	for rows.Next() {
		err = rows.Scan(
			&battery.Name,
		)
		batteries = append(batteries, battery)
	}
	return batteries, err
}
