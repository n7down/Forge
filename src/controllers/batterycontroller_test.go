package controllers

import (
	"net/http"
	"net/http/httptest"
	"testing"

	"github.com/gin-gonic/gin"
	"github.com/n7down/Forge/src/models"
	"github.com/stretchr/testify/assert"

	"github.com/golang/mock/gomock"
	"github.com/n7down/Forge/src/mocks"
)

func TestGetBatteriesNoContent(t *testing.T) {
	mockCtrl := gomock.NewController(t)
	defer mockCtrl.Finish()

	mockBatteryDatastore := mocks.NewMockBatteryDatastore(mockCtrl)
	mockBatteryDatastore.EXPECT().GetAllBatteries().Return(nil, nil)

	assert := assert.New(t)

	gin.SetMode(gin.TestMode)
	env := &Env{DB: mockBatteryDatastore}

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
	env := &Env{DB: mockBatteryDatastore}

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
