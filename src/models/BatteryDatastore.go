package models

type BatteryDatastore interface {
	GetAllBatteries() ([]*BatteryResponse, error)
}
