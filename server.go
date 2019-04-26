package main

import (
	"fmt"
	"github.com/gin-gonic/gin"
	"github.com/n7down/Forge/controllers"
	"github.com/n7down/Forge/models"
)

func main() {
	d, err := models.GetDB()
	if err != nil {
		fmt.Printf("error starting the database: %v", err.Error())
		return
	}

	// FIXME: how do i get this to work with different datastores?

	//battery := &models.Battery{Db: d}
	//motor := &models.Motor{Db: d}

	env := &controllers.Env{Datastore: d}

	router := gin.Default()

	//env := &controllers.Env{Datastore: battery}
	router.GET("/battery", env.GetBatteries)
	router.POST("/battery", env.AddBattery)

	//env = &controllers.Env{Datastore: motor}
	//router.GET("/motor", env.GetMotors)
	//router.POST("/motor", env.AddMotor)

	router.Run()
}
