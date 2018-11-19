package main

import (
	"net/http"
	"net/http/httptest"
	"testing"

	"github.com/gin-gonic/gin"
	models "github.com/n7down/Forge/src/models"
)

type mockedDB struct{}

type mockedEnv struct {
	db mockedDB
}

func (db *mockedDB) GetAllBatteries() ([]*models.BatteryResponse, error) {
	batteries := make([]*models.BatteryResponse, 0)
	batteries = append(batteries, &models.BatteryResponse{1, "test-battery0"})
	batteries = append(batteries, &models.BatteryResponse{2, "test-battery1"})
	return batteries, nil
}

func (m *mockedEnv) GetBatteriesController(c *gin.Context) {
	batteries, err := m.db.GetAllBatteries()
	if err != nil {
		c.JSON(http.StatusInternalServerError, err.Error())
	}
	c.JSON(http.StatusOK, batteries)
}

func TestGetBatteries(t *testing.T) {
	gin.SetMode(gin.TestMode)
	env := &mockedEnv{db: mockedDB{}}

	router := gin.Default()
	router.GET("/battery", env.GetBatteriesController)
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
