package repository

import (
	"testing"

	data "github.com/n7down/Forge/src/database"
	"github.com/n7down/Forge/src/models"
)

func TestBattery(t *testing.T) {
	battery := models.Battery{
		"test-battery",
	}

	data.InitDb()
	CreateBattery(battery)
}
