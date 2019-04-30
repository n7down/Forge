package models

//go:generate mockgen -destination=../mocks/mock_batteryrepository.go -package=mocks github.com/n7down/Forge/models BatteryRepository
type BatteryRepository interface {
	GetAllBatteries() ([]*BatteryResponse, error)
	AddBattery(BatteryRequest) error
}
