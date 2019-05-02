package models

import (
	"database/sql"
	"os"

	_ "github.com/lib/pq"
)

//go:generate mockgen -destination=../mocks/mock_repository.go -package=mocks github.com/n7down/Forge/models Repository
type Repository interface {
	GetAllBatteries() ([]*BatteryResponse, error)
	AddBattery(BatteryRequest) error

	GetAllMotors() ([]*MotorResponse, error)
	AddMotor(MotorRequest) error
}

type repository struct {
	db *sql.DB
}

func getEnv(key, fallback string) string {
	if value, ok := os.LookupEnv(key); ok {
		return value
	}
	return fallback
}

func NewRepository() (Repository, error) {
	dbUser := "postgres"
	dbPassword := "postgres"
	dbName := "forge"
	dbHost := getEnv("DB_HOST", "localhost")
	connectionString := "postgres://" + dbUser + ":" + dbPassword + "@" + dbHost + "/" + dbName + "?sslmode=disable"

	db, err := sql.Open("postgres", connectionString)
	if err != nil {
		return nil, err
	}
	return &repository{db: db}, nil
}

func GetDB() (*sql.DB, error) {
	dbUser := "postgres"
	dbPassword := "postgres"
	dbName := "forge"
	dbHost := getEnv("DB_HOST", "localhost")
	connectionString := "postgres://" + dbUser + ":" + dbPassword + "@" + dbHost + "/" + dbName + "?sslmode=disable"

	db, err := sql.Open("postgres", connectionString)
	if err != nil {
		return nil, err
	}
	return db, nil
}
