package repository

import (
	"fmt"
	"testing"

	data "github.com/n7down/Forge/src/database"
	request "github.com/n7down/Forge/src/models"
)

// TODO: figure out how to mock a repository

func TestBattery(t *testing.T) {
	battery := request.Battery{
		"test-battery2",
	}

	data.InitDb()
	CreateBattery(battery)
}

func TestGetBatteries(t *testing.T) {
	data.InitDb()
	d, _ := GetBatteries()
	fmt.Println(d)
}
