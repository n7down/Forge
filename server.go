package main

import (
	"github.com/gin-gonic/gin"
	"github.com/n7down/Forge/controllers"
	"github.com/n7down/Forge/models"
)

func main() {
	db, err := models.GetDb()
	if err != nil {

	}
	env := &controllers.Env{Db: db}

	router := gin.Default()

	router.GET("/battery", env.GetBatteries)
	router.POST("/battery", env.AddBattery)
	router.Run()
}
