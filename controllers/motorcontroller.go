package controllers

import (
	"net/http"

	"github.com/gin-gonic/gin"
	"github.com/n7down/Forge/models"
)

func (e *MotorEnv) GetMotors(c *gin.Context) {
	motors, err := e.Repository.GetAllMotors()
	if err != nil {
		c.JSON(http.StatusInternalServerError, err.Error())
	}
	if len(motors) == 0 {
		c.JSON(http.StatusNoContent, motors)
	}
	c.JSON(http.StatusOK, motors)
}

func (e *MotorEnv) AddMotor(c *gin.Context) {
	var in models.MotorRequest
	c.BindJSON(&in)
	err := e.Repository.AddMotor(in)
	if err != nil {
		c.JSON(http.StatusInternalServerError, err.Error())
	}
	c.JSON(http.StatusOK, gin.H{
		"message": "motor created",
	})
}
