package models

//go:generate mockgen -destination=../mocks/mock_motorrepository.go -package=mocks github.com/n7down/Forge/models MotorRepository
type MotorRepository interface {
	GetAllMotors() ([]*MotorResponse, error)
	AddMotor(MotorRequest) error
}
