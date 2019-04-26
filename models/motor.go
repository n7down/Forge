package models

import ()

type MotorRequest struct {
	Name string `json:"name"`
}

type MotorResponse struct {
	Id   int    `json:"id"`
	Name string `json:"name"`
}

func (m DB) GetAllMotors() ([]*MotorResponse, error) {
	var err error

	query := "SELECT id, name FROM motor"
	rows, err := m.Db.Query(query)
	if err != nil {
		return nil, err
	}
	defer rows.Close()
	motors := make([]*MotorResponse, 0)
	for rows.Next() {
		motor := new(MotorResponse)
		err = rows.Scan(
			&motor.Id,
			&motor.Name,
		)
		motors = append(motors, motor)
	}
	if err = rows.Err(); err != nil {
		return nil, err
	}
	return motors, nil
}

func (m DB) AddMotor(in MotorRequest) error {
	var err error
	query := "INSERT INTO motor (name) VALUES ($1)"
	_, err = m.Db.Query(query, in.Name)
	return err
}
