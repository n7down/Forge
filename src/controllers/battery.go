package controllers

import (
	"github.com/gin-gonic/gin"
)

func GetBatteries(c *gin.Context) {
	c.JSON(200, gin.H{
		"message": "batteries",
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
