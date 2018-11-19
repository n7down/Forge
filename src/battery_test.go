package main

import (
	"net/http"
	"net/http/httptest"
	"testing"

	"github.com/gin-gonic/gin"
	models "github.com/n7down/Forge/src/models"
)

type MockedDB struct{}

func (db *MockedDB) GetAllBatteries() ([]*models.BatteryResponse, error) {
	batteries := make([]*models.BatteryResponse, 0)
	batteries = append(batteries, &models.BatteryResponse{1, "test-battery0"})
	batteries = append(batteries, &models.BatteryResponse{2, "test-battery1"})
	return batteries, nil
}

func TestGetBatteries(t *testing.T) {
	gin.SetMode(gin.TestMode)
	env := &Env{db: &MockedDB{}}

	router := gin.Default()
	router.GET("/battery", env.GetBatteries)
	req, err := http.NewRequest(http.MethodGet, "/battery", nil)

	if err != nil {
		t.Fatalf("Couldn't create request: %v\n", err)
	}
	w := httptest.NewRecorder()

	router.ServeHTTP(w, req)

	if w.Code != http.StatusOK {
		t.Fatalf("Expected to get status %d but instead got %d\n", http.StatusOK, w.Code)
	}
	expected := "[{\"id\":1,\"name\":\"test-battery0\"},{\"id\":2,\"name\":\"test-battery1\"}]"
	actual := w.Body.String()
	if expected != actual {
		t.Errorf("\n...expected = %v\n...obtained = %v", expected, w.Body.String())
	}
}
