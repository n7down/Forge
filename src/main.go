package main

import (
	"net/http"

	"github.com/gin-gonic/gin"
	"github.com/n7down/Forge/src/models"
)

type Env struct {
	db models.BatteryDatastore
}

func (e *Env) GetBatteries(c *gin.Context) {
	batteries, err := e.db.GetAllBatteries()
	if err != nil {
		c.JSON(http.StatusInternalServerError, err.Error())
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

// func (e *Env) AddBattery(c *gin.Context) {
// 	var in models.BatteryRequest
// 	c.BindJSON(&in)
// 	query := "INSERT INTO battery (name) VALUES (?)"
// 	_, err := e.db.Exec(query, in.Name)
// 	if err != nil {
// 		c.JSON(http.StatusInternalServerError, err.Error())
// 	}

// 	c.JSON(200, gin.H{
// 		"message": "battery created",
// 	})
// }

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

func main() {
	db, err := models.GetDb()
	if err != nil {

	}
	env := &Env{db}

	router := gin.Default()

	router.GET("/battery", env.GetBatteries)
	// router.POST("/battery", AddBattery)
	router.Run()
}
