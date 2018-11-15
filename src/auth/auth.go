package auth

import (
	"errors"
	"fmt"

	jwt "github.com/dgrijalva/jwt-go"
)

func validateAlg(token *jwt.Token) (interface{}, error) {
	if _, ok := token.Method.(*jwt.SigningMethodHMAC); !ok {
		return nil, fmt.Errorf("Unexpected signing method: %v", token.Header["alg"])
	}
	return []byte("your-256-bit-secret"), nil
}

func ParseClaims(tokenString string) (Claims, error) {
	token, err := jwt.Parse(tokenString, validateAlg)
	if err != nil {
		return Claims{}, errors.New("Token error")
	}
	claims := token.Claims.(jwt.MapClaims)
	var c Claims
	c.Foo = claims["foo"].(string)
	return c, nil
}
