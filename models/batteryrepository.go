package models

import (
	"database/sql"
)

//go:generate mockgen -destination=../mocks/mock_batteryrepository.go -package=mocks github.com/n7down/Forge/models BatteryRepository
type BatteryRepository interface {
	GetAllBatteries(*sql.DB) ([]*BatteryResponse, error)
	AddBattery(*sql.DB, BatteryRequest) error
}
