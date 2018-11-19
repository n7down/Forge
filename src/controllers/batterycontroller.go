package controllers

import (
	"net/http"

	"github.com/gin-gonic/gin"
)

func (e *Env) GetBatteries(c *gin.Context) {
	batteries, err := e.Db.GetAllBatteries()
	if err != nil {
		c.JSON(http.StatusInternalServerError, err.Error())
	}
	if len(batteries) == 0 {
		c.JSON(http.StatusNoContent, batteries)
	}
	c.JSON(http.StatusOK, batteries)
}

func GetBatteryById(c *gin.Context) {
	id := c.Param("id")
	c.JSON(200, gin.H{
		"message": "battery",
		"id":      id,
	})
}

func (e *Env) AddBattery(c *gin.Context) {
	// var in models.BatteryRequest
	// c.BindJSON(&in)
	// query := "INSERT INTO battery (name) VALUES (?)"
	// _, err := e.db.Exec(query, in.Name)
	// if err != nil {
	// 	c.JSON(http.StatusInternalServerError, err.Error())
	// }

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
