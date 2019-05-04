package controllers

import (
	"net/http"

	"github.com/gin-gonic/gin"
	"github.com/n7down/Forge/models"
)

func (e *BatteryEnv) GetBatteries(c *gin.Context) {
	batteries, err := e.Repository.GetAllBatteries()
	if err != nil {
		c.JSON(http.StatusInternalServerError, err.Error())
	}
	if len(batteries) == 0 {
		c.JSON(http.StatusNoContent, batteries)
	}
	c.JSON(http.StatusOK, batteries)
}

func (e *BatteryEnv) AddBattery(c *gin.Context) {
	var in models.BatteryRequest
	c.BindJSON(&in)
	err := e.Repository.AddBattery(in)
	if err != nil {
		c.JSON(http.StatusInternalServerError, err.Error())
	}
	c.JSON(http.StatusOK, gin.H{
		"message": "battery created",
	})
}

func GetBatteryById(c *gin.Context) {
	id := c.Param("id")
	c.JSON(http.StatusOK, gin.H{
		"message": "battery",
		"id":      id,
	})
}

func DeleteBattery(c *gin.Context) {
	c.JSON(200, gin.H{
		"message": "battery deleted",
	})
}

func UpdateBattery(c *gin.Context) {
	c.JSON(200, gin.H{
		"message": "battery updated",
	})
}
