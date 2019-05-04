package main

import (
	"fmt"
	"github.com/gin-gonic/gin"
	"github.com/n7down/Forge/controllers"
	"github.com/n7down/Forge/models"
)

func main() {
	//repository, err := models.NewRepository()
	//if err != nil {
	//fmt.printf("error starting the database: %v", err.error())
	//return
	//}

	//router := gin.default()

	//env := &controllers.Env{Repository: repository}

	//router.GET("/battery", env.GetBatteries)
	//router.POST("/battery", env.AddBattery)

	db, err := models.GetDB()
	if err != nil {
		fmt.Printf("error starting the database: %v", err.Error())
		return
	}

	router := gin.Default()

	battery := models.Battery{Db: db}
	batteryEnv := &controllers.BatteryEnv{Repository: battery}
	router.GET("/battery", batteryEnv.GetBatteries)
	router.POST("/battery", batteryEnv.AddBattery)

	motor := models.Motor{Db: db}
	motorEnv := &controllers.MotorEnv{Repository: motor}
	router.GET("/motor", motorEnv.GetMotors)
	router.POST("/motor", motorEnv.AddMotor)

	router.Run()
}
