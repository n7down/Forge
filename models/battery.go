package models

type BatteryRequest struct {
	Name string `json:"name"`
}

type BatteryResponse struct {
	Id   int    `json:"id"`
	Name string `json:"name"`
}

func (d *Datastore) GetAllBatteries() ([]*BatteryResponse, error) {
	var err error

	query := "SELECT id, name FROM battery"
	rows, err := d.Db.Query(query)
	if err != nil {
		return nil, err
	}
	defer rows.Close()
	batteries := make([]*BatteryResponse, 0)
	for rows.Next() {
		battery := new(BatteryResponse)
		err = rows.Scan(
			&battery.Id,
			&battery.Name,
		)
		batteries = append(batteries, battery)
	}
	if err = rows.Err(); err != nil {
		return nil, err
	}
	return batteries, nil
}

func (d *Datastore) AddBattery(in BatteryRequest) error {
	var err error
	query := "INSERT INTO battery (name) VALUES ($1)"
	_, err = d.Db.Query(query, in.Name)
	return err
}
