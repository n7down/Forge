package controllers

import (
	"github.com/gin-gonic/gin"
	auth "github.com/n7down/Forge/src/auth"
	models "github.com/n7down/Forge/src/models"
)

func UserLogin(c *gin.Context) {
	var in models.UserData
	c.BindJSON(&in)
	auth.ParseClaims(in)
}
