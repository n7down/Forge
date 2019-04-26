package models

//go:generate mockgen -destination=../mocks/mock_motordatastore.go -package=mocks github.com/n7down/Forge/models MotorDatastore
type MotorDatastore interface {
	GetAllMotors() ([]*MotorResponse, error)
	AddMotor(MotorRequest) error
}
