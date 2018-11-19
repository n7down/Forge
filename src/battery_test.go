package main

import (
	"github.com/gin-gonic/gin"
	models "github.com/n7down/Forge/src/models"
)

type mockedEnv struct{}

func (m *mockedEnv) GetBatteries(c *gin.Context) error {
	batteries := make([]*models.BatteryRequest, 0)
	batteries = append(batteries, &models.BatteryRequest{1, "test-battery0"})
	batteries = append(batteries, &models.BatteryRequest{2, "test-battery1"})
	return batteries, nil
}
