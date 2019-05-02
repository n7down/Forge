package main

import (
	"fmt"
	"github.com/gin-gonic/gin"
	"github.com/n7down/Forge/controllers"
	"github.com/n7down/Forge/models"
)

func main() {
	repository, err := models.NewRepository()
	if err != nil {
		fmt.Printf("error starting the database: %v", err.Error())
		return
	}

	router := gin.Default()

	env := &controllers.Env{Repository: repository}

	router.GET("/battery", env.GetBatteries)
	router.POST("/battery", env.AddBattery)

	//router.GET("/motor", env.GetMotors)
	//router.POST("/motor", env.AddMotor)

	router.Run()
}
