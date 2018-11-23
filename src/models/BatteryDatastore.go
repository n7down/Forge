package models

//go:generate mockgen -destination=../mocks/mock_batterydatastore.go -package=mocks github.com/n7down/Forge/src/models BatteryDatastore

type BatteryDatastore interface {
	GetAllBatteries() ([]*BatteryResponse, error)
	AddBattery(BatteryRequest) error
}
