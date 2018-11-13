package controllers

import (
	"github.com/gin-gonic/gin"
	request "github.com/n7down/Forge/src/models"
	repository "github.com/n7down/Forge/src/repository"
)

func GetBatteries(c *gin.Context) {
	d, _ := repository.GetBatteries()
	c.JSON(200, gin.H{
		"data": d,
	})
}

func GetBatteryById(c *gin.Context) {
	id := c.Param("id")
	c.JSON(200, gin.H{
		"message": "battery",
		"id":      id,
	})
}

func AddBattery(c *gin.Context) {
	var in request.Battery
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
