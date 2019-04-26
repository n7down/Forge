package controllers

import (
	"bytes"
	"net/http"
	"net/http/httptest"
	"testing"

	"github.com/gin-gonic/gin"
	"github.com/n7down/Forge/models"
	"github.com/stretchr/testify/assert"

	"github.com/golang/mock/gomock"
	"github.com/n7down/Forge/mocks"
)

func TestGetBatteriesNoContent(t *testing.T) {
	mockCtrl := gomock.NewController(t)
	defer mockCtrl.Finish()

	mockBatteryDatastore := mocks.NewMockBatteryDatastore(mockCtrl)
	mockBatteryDatastore.EXPECT().GetAllBatteries().Return(nil, nil)

	assert := assert.New(t)

	gin.SetMode(gin.TestMode)
	env := &Env{Datastore: mockBatteryDatastore}

	router := gin.Default()
	router.GET("/battery", env.GetBatteries)
	req, err := http.NewRequest(http.MethodGet, "/battery", nil)

	assert.Nil(err, "Couldn't create request: %v\n", err)

	w := httptest.NewRecorder()

	router.ServeHTTP(w, req)

	expectedStatusCode := http.StatusNoContent
	assert.Equal(w.Code, expectedStatusCode, "Expected to get status %d but instead got %d\n", w.Code, expectedStatusCode)
}

func TestGetBatteriesWithContent(t *testing.T) {
	mockCtrl := gomock.NewController(t)
	defer mockCtrl.Finish()

	mockBatteryDatastore := mocks.NewMockBatteryDatastore(mockCtrl)

	batteries := make([]*models.BatteryResponse, 0)
	batteries = append(batteries, &models.BatteryResponse{1, "test-battery0"})
	batteries = append(batteries, &models.BatteryResponse{2, "test-battery1"})

	mockBatteryDatastore.EXPECT().GetAllBatteries().Return(batteries, nil)

	assert := assert.New(t)

	gin.SetMode(gin.TestMode)
	env := &Env{Datastore: mockBatteryDatastore}

	router := gin.Default()
	router.GET("/battery", env.GetBatteries)
	req, err := http.NewRequest(http.MethodGet, "/battery", nil)

	assert.Nil(err, "Couldn't create request: %v\n", err)

	w := httptest.NewRecorder()

	router.ServeHTTP(w, req)

	assert.Equal(w.Code, http.StatusOK, "Expected to get status %d but instead got %d\n", w.Code, http.StatusOK)
	expected := "[{\"id\":1,\"name\":\"test-battery0\"},{\"id\":2,\"name\":\"test-battery1\"}]"
	actual := w.Body.String()
	assert.Equal(expected, actual, "Expected to get %v but instead got %v \n", expected, actual)
}

func TestAddBattery(t *testing.T) {
	mockCtrl := gomock.NewController(t)
	defer mockCtrl.Finish()

	mockBatteryDatastore := mocks.NewMockBatteryDatastore(mockCtrl)

	var battery models.BatteryRequest
	battery.Name = "test-battery"

	mockBatteryDatastore.EXPECT().AddBattery(battery).Return(nil)

	var jsonStr = []byte(`{"name":"test-battery"}`)
	assert := assert.New(t)

	gin.SetMode(gin.TestMode)
	env := &Env{Datastore: mockBatteryDatastore}

	router := gin.Default()
	router.POST("/battery", env.AddBattery)
	req, err := http.NewRequest(http.MethodPost, "/battery", bytes.NewBuffer(jsonStr))

	assert.Nil(err, "Couldn't create request: %v\n", err)

	w := httptest.NewRecorder()

	router.ServeHTTP(w, req)

	assert.Equal(http.StatusOK, w.Code, "Expected to get status %d but instead got %d\n", http.StatusOK, w.Code)
	expected := "{\"message\":\"battery created\"}"
	actual := w.Body.String()
	assert.Equal(expected, actual, "Expected to get %v but instead got %v \n", expected, actual)
}
