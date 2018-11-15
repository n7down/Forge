package auth

import (
	"errors"
	"fmt"

	jwt "github.com/dgrijalva/jwt-go"
	models "github.com/n7down/Forge/src/models"
)

func validateAlg(token *jwt.Token) (interface{}, error) {
	if _, ok := token.Method.(*jwt.SigningMethodHMAC); !ok {
		return nil, fmt.Errorf("Unexpected signing method: %v", token.Header["alg"])
	}
	return []byte("your-256-bit-secret"), nil
}

func ParseClaims(tokenString string) (models.Claims, error) {
	token, err := jwt.Parse(tokenString, validateAlg)
	if err != nil {
		return models.Claims{}, errors.New("Token error")
	}
	claims := token.Claims.(jwt.MapClaims)
	var c models.Claims
	c.Foo = claims["foo"].(string)
	return c, nil
}
