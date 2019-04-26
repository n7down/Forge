package main

import (
	"fmt"
	"github.com/gin-gonic/gin"
	"github.com/n7down/Forge/controllers"
	"github.com/n7down/Forge/models"
)

func main() {
	d, err := models.GetDatastore()
	if err != nil {
		fmt.Printf("error starting the database: %v", err.Error())
		return
	}
	env := &controllers.Env{Datastore: d}

	router := gin.Default()

	router.GET("/battery", env.GetBatteries)
	router.POST("/battery", env.AddBattery)
	router.Run()
}
