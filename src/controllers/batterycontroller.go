package controllers

import (
	"net/http"

	"github.com/gin-gonic/gin"
	models "github.com/n7down/Forge/src/models"
	repository "github.com/n7down/Forge/src/repository"
)

type BatteryInterface interface {
	GetBatteries(c *gin.Context)
	GetBatteryById(c *gin.Context)
	AddBattery(c *gin.Context)
	DeleteBattery(c *gin.Context)
	UpdateBattery(c *gin.Context)
}

func GetBatteries(c *gin.Context) {
	d, _ := repository.GetBatteries()
	c.JSON(http.StatusOK, d)
}

func GetBatteryById(c *gin.Context) {
	id := c.Param("id")
	c.JSON(200, gin.H{
		"message": "battery",
		"id":      id,
	})
}

func AddBattery(c *gin.Context) {
	var in models.BatteryRequest
	c.BindJSON(&in)
	repository.CreateBattery(in)

	c.JSON(200, gin.H{
		"message": "battery created",
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
