package main

import (
	"fmt"
	"github.com/gin-gonic/gin"
	"github.com/n7down/Forge/controllers"
	"github.com/n7down/Forge/models"
)

func main() {
	db, err := models.GetDB()
	if err != nil {
		fmt.Printf("error starting the database: %v", err.Error())
		return
	}

	router := gin.Default()

	env := &controllers.Env{Db: db}

	router.GET("/battery", env.GetBatteries)
	router.POST("/battery", env.AddBattery)

	//router.GET("/motor", env.GetMotors)
	//router.POST("/motor", env.AddMotor)

	router.Run()
}
