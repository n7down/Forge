package main

import (
	"github.com/gin-gonic/gin"
	controllers "github.com/n7down/Forge/src/controllers"
	data "github.com/n7down/Forge/src/database"
)

func main() {
	err := data.InitDb()
	if err != nil {

	}

	router := gin.Default()

	router.GET("/ping", func(c *gin.Context) {
		c.JSON(200, gin.H{
			"message": "pong",
		})
	})

	router.GET("/battery", controllers.GetBatteries)
	router.GET("/battery/:id", controllers.GetBatteryById)
	router.POST("/battery", controllers.AddBattery)
	router.PUT("/battery", controllers.UpdateBattery)
	router.DELETE("/battery/:id", controllers.DeleteBattery)

	router.POST("/user/login", controllers.UserLogin)

	router.Run(":8080")
}
