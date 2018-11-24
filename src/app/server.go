package main

import (
	"github.com/gin-gonic/gin"
	"github.com/n7down/Forge/src/controllers"
	"github.com/n7down/Forge/src/models"
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
