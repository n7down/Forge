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

func GetBatteries() (response.Battery, error) {
	var batteries response.Battery
	var err error
	// query := "SELECT * FROM battery"
	// db, err := data.GetDb()
	// if err != nil {
	// 	return batteries, err
	// }
	// rows, err := db.Exec(query)
	// defer rows.Close()
	// for rows.Next() {
	// 	err = rows.Scan(
	// 		&batteries.Name,
	// 	)
	// }
	return batteries, err
}
