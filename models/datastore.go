package models

type Datastore interface {
	GetAll() ([]*interface{}, error)
	Add(interface{}) error
}
