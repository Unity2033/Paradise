using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Google.Play.AppUpdate;
using Google.Play.Common;

public class In_App_Update : MonoBehaviour
{
    AppUpdateManager app_update_manager;

    void Start()
    {
        StartCoroutine(Check_Update());
    }

    IEnumerator Check_Update()
    {
        PlayAsyncOperation<AppUpdateInfo, AppUpdateErrorCode> appuUpdateInfoOperation =
            app_update_manager.GetAppUpdateInfo();

        // 비동기 작업이 완료될 때 까지 대기
        yield return appuUpdateInfoOperation;

        if(appuUpdateInfoOperation.IsSuccessful)
        {
            var appUpdateInforResult = appuUpdateInfoOperation.GetResult();
            // 앱 업데이트 정보 업데이트 가용성, 업데이트 우선사항, 
            // IsupdateTypeAllowed() 등을 확인하고 사용자에게 인앱 업데이트를 시작하도록 요청할지 여부를 결정합니다.

            // 업데이트 여부 표시
            if(appUpdateInforResult.UpdateAvailability == UpdateAvailability.UpdateAvailable)
            {

            }
            else
            {

            }

            // 즉각적인 인앱을 정의하는 AppUpdateOptions 생성 업데이트 흐름 및 해당 매개변수
            var appUpdateOptions = AppUpdateOptions.ImmediateAppUpdateOptions();
            StartCoroutine(StartImmediateUpdate(appUpdateInforResult, appUpdateOptions));
        }
    }

    IEnumerator StartImmediateUpdate(AppUpdateInfo appUpdateInforOp_i,AppUpdateOptions appUpdateOptions_i)
    {
        // 요청된 앱 업데이트 흐름을 모니터링하는 데 사용할 수 있는 AppUpdateRequest를 만듭니다.
        var startUpdateRequest = app_update_manager.StartUpdate(
            //playasyncOperation.getResult()에서 반환된 결과입니다.
            appUpdateInforOp_i,
            appUpdateOptions_i
            );

        yield return startUpdateRequest;

        // 업데이트가 성공적으로 완료되면 앱이 다시 시작되고 이 줄에 도달하지 않습니다.
        // 이 줄에 도달하면 실패를 처리합니다(예: reult.Error를 기록하거나 사용자에게 메시지를 표시하여).
    }
}
