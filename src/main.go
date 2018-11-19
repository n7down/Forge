package main

import (
	"database/sql"
	"net/http"

	"github.com/gin-gonic/gin"
	"github.com/n7down/Forge/src/models"
)

type Env struct {
	db *sql.DB
}

func (e *Env) GetBatteries(c *gin.Context) {
	var (
		battery   models.BatteryResponse
		batteries []models.BatteryResponse
		err       error
	)

	query := "SELECT id, name FROM battery"
	rows, err := e.db.Query(query)
	if err != nil {
		c.JSON(http.StatusInternalServerError, err.Error())
	}
	defer rows.Close()
	for rows.Next() {
		err = rows.Scan(
			&battery.Id,
			&battery.Name,
		)
		batteries = append(batteries, battery)
	}
	if err != nil {
		c.JSON(http.StatusInternalServerError, err.Error())
	}
	c.JSON(http.StatusOK, batteries)
}

func (e *Env) GetBatteryById(c *gin.Context) {
	id := c.Param("id")
	c.JSON(200, gin.H{
		"message": "battery",
		"id":      id,
	})
}

func (e *Env) AddBattery(c *gin.Context) {
	var in models.BatteryRequest
	c.BindJSON(&in)
	query := "INSERT INTO battery (name) VALUES (?)"
	_, err := e.db.Exec(query, in.Name)
	if err != nil {
		c.JSON(http.StatusInternalServerError, err.Error())
	}

	c.JSON(200, gin.H{
		"message": "battery created",
	})
}

func (e *Env) DeleteBattery(c *gin.Context) {
	c.JSON(200, gin.H{
		"message": "battery deleted",
	})
}

func (e *Env) UpdateBattery(c *gin.Context) {
	c.JSON(200, gin.H{
		"message": "battery updated",
	})
}

func main() {
	db, err := models.GetDb()
	if err != nil {

	}
	env := &Env{db: db}

	router := gin.Default()

	router.GET("/battery", env.GetBatteries)
	router.GET("/battery/:id", env.GetBatteryById)
	router.POST("/battery", env.AddBattery)
	router.PUT("/battery", env.UpdateBattery)
	router.DELETE("/battery/:id", env.DeleteBattery)
	router.Run()
}
