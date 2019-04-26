package models

type Datastore interface {
	GetAllBatteries() ([]*BatteryResponse, error)
	AddBattery(BatteryRequest) error

	GetAllMotors() ([]*MotorResponse, error)
	AddMotor(MotorRequest) error
}
